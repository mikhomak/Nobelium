using System.Collections.Generic;
using UnityEngine;

public class BoxPoints : MonoBehaviour {
    [SerializeField] private List<Point> points = new List<Point>();
    [SerializeField] private int maxPoints;

    public int getMaxPoints() {
        return maxPoints;
    }

    private void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            points.Add(new Point(transform.GetChild(i).transform.position, false));
        }
        maxPoints = transform.childCount;
    }

    public Vector2 getRandomPosition() {
        int randomPoint = Random.Range(0, points.Count);
        while (points[randomPoint].getTaken()) {
            randomPoint = Random.Range(0, points.Count);
        }

        points[randomPoint].setTaken(true);
        return points[randomPoint].getPosition();
    }

    public void updatePointsTaken() {
        foreach (Point point in points) {
            point.setTaken(false);
        }
    }

    private class Point {
        private Vector2 position;
        private bool taken;

        public Point(Vector2 position, bool taken) {
            this.position = position;
            this.taken = taken;
        }

        public void setPosition(Vector2 position) {
            this.position = position;
        }

        public Vector2 getPosition() {
            return position;
        }

        public void setTaken(bool taken) {
            this.taken = taken;
        }

        public bool getTaken() {
            return taken;
        }
    }
}